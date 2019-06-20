package com.sharipov.app.leagueScreen.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.sharipov.app.R
import com.sharipov.app.db.entity.League

class LeagueListAdapter : RecyclerView.Adapter<LeagueListAdapter.ViewHolder>() {

    private var onSelectListener: ((League, Boolean) -> Unit)? = null

    private val list = ArrayList<League>()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val layoutInflater = LayoutInflater.from(parent.context)
        return ViewHolder(
            layoutInflater.inflate(
                R.layout.league_list_item,
                parent,
                false
            )
        )
    }

    fun setOnSelectListener(listener: (League, Boolean) -> Unit) {
        this.onSelectListener = listener
    }

    override fun getItemCount(): Int = list.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item: League = list[position]

        holder.textTv.text = item.name
        holder.checkBox.isChecked = item.isWatched

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

    private fun setCheckedByHands(holder: ViewHolder) {
        holder.checkBox.isChecked = !holder.checkBox.isChecked
    }

    fun updateItems(it: ArrayList<League>) {
        list.clear()
        list.addAll(it)
        notifyDataSetChanged()
    }

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val textTv: TextView = view.findViewById(R.id.text)!!
        val checkBox: CheckBox = view.findViewById(R.id.checkBox)!!
        val parent: View = view.findViewById(R.id.parent)!!
    }
}