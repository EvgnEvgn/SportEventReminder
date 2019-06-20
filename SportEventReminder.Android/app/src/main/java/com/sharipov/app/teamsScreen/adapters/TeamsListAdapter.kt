package com.sharipov.app.teamsScreen.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.sharipov.app.R
import com.sharipov.app.db.entity.Team

class TeamsListAdapter : RecyclerView.Adapter<TeamsListAdapter.ViewHolder>() {

    private val list = ArrayList<Team>()

    private var onSelectListener: ((Team, Boolean) -> Unit)? = null

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val layoutInflater = LayoutInflater.from(parent.context)
        return ViewHolder(
            layoutInflater.inflate(
                R.layout.team_list_item,
                parent,
                false
            )
        )
    }

    fun setOnSelectListener(listener: (Team, Boolean) -> Unit) {
        this.onSelectListener = listener
    }

    override fun getItemCount(): Int = list.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item: Team = list[position]

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


    fun updateItems(it: ArrayList<Team>) {
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