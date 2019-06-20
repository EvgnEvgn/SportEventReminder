package com.sharipov.app.matchScreen.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.sharipov.app.R
import com.sharipov.app.matchScreen.MatchListItem
import java.text.SimpleDateFormat
import java.util.*
import kotlin.collections.ArrayList


class MatchListAdapter : RecyclerView.Adapter<MatchListAdapter.ViewHolder>() {

    private var onSelectListener: ((MatchListItem, Boolean) -> Unit)? = null

    private val list = ArrayList<MatchListItem>()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val layoutInflater = LayoutInflater.from(parent.context)
        return ViewHolder(
            layoutInflater.inflate(
                R.layout.match_list_item,
                parent,
                false
            )
        )
    }

    fun setOnSelectListener(listener: (MatchListItem, Boolean) -> Unit) {
        this.onSelectListener = listener
    }

    override fun getItemCount(): Int = list.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item: MatchListItem = list[position]

        holder.textTv.text = """${item.teamHome}  VS  ${item.teamAway}"""
        holder.leagueTv.text = "League: " + item.leagueString
        holder.dateTv.text = "Date: " + item.getDateString()

        holder.checkBox.isChecked = item.match.isWatched

        holder.textTv.setOnClickListener {
            setCheckedByHands(holder)
        }
        holder.parent.setOnClickListener {
            setCheckedByHands(holder)
        }

        holder.checkBox.setOnCheckedChangeListener { _, isChecked ->
            run {
                onSelectListener?.invoke(item, isChecked)
            }
        }
    }

    fun updateItems(it: ArrayList<MatchListItem>) {
        list.clear()
        list.addAll(it)
        notifyDataSetChanged()
    }

    private fun setCheckedByHands(holder: ViewHolder) {
        holder.checkBox.isChecked = !holder.checkBox.isChecked
    }

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val textTv: TextView = view.findViewById(R.id.text)!!
        val leagueTv: TextView = view.findViewById(R.id.leagueTv)!!
        val dateTv: TextView = view.findViewById(R.id.dateTv)!!
        val checkBox: CheckBox = view.findViewById(R.id.checkBox)!!
        val parent: View = view.findViewById(R.id.parent)!!
    }

    private fun MatchListItem.getDateString(): String {
        val formatter = SimpleDateFormat("dd.MM.y hh:mm")
        return formatter.format(Date(match.startDate))
    }
}
