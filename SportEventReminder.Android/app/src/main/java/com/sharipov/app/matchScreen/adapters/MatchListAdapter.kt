package com.sharipov.app.matchScreen.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.sharipov.app.R
import com.sharipov.app.db.entity.Match


class MatchListAdapter : RecyclerView.Adapter<MatchListAdapter.ViewHolder>() {

    private var onSelectListener: ((Match, Boolean) -> Unit)? = null

    private val list = ArrayList<Match>()

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

    fun setOnSelectListener(listener: (Match, Boolean) -> Unit) {
        this.onSelectListener = listener
    }

    override fun getItemCount(): Int = list.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item: Match = list[position]

        holder.textTv.text = item.getMatchString()
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

    fun updateItems(it: ArrayList<Match>) {
        list.clear()
        list.addAll(it)
        notifyDataSetChanged()
    }

    private fun setCheckedByHands(holder: ViewHolder) {
        holder.checkBox.isChecked = !holder.checkBox.isChecked
    }


    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val textTv: TextView = view.findViewById(R.id.text)!!
        val checkBox: CheckBox = view.findViewById(R.id.checkBox)!!
        val parent: View = view.findViewById(R.id.parent)!!
    }
}

private fun Match.getMatchString(): CharSequence? {
    return "lol"//TODO
}
