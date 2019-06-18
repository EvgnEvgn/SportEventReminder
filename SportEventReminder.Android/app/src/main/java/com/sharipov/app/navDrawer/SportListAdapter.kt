package com.sharipov.app.navDrawer

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.sharipov.app.R
import com.sharipov.app.navDrawer.models.SportItem

class SportListAdapter : RecyclerView.Adapter<SportListAdapter.ViewHolder>() {

    private val list = ArrayList<SportItem>()
    private lateinit var listener: (SportItem) -> Unit

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val layoutInflater = LayoutInflater.from(parent.context)
        return ViewHolder(layoutInflater.inflate(R.layout.sport_list_item, parent, false))
    }

    override fun getItemCount(): Int = list.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item: SportItem = list[position]

        holder.logoImageView.setImageResource(item.icon)
        holder.textTv.text = item.name
        holder.textTv.text = item.name

        holder.textTv.setOnClickListener(onClickListener(item))
        holder.logoImageView.setOnClickListener(onClickListener(item))
        holder.sportListItemParent.setOnClickListener(onClickListener(item))
    }

    private fun onClickListener(item: SportItem): (View) -> Unit = {
        listener.invoke(item)
    }

    fun updateItems(it: ArrayList<SportItem>) {
        list.clear()
        list.addAll(it)
        notifyDataSetChanged()
    }

    fun setOnClickListener(listener: (SportItem) -> Unit) {
        this.listener = listener
    }

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val textTv: TextView = view.findViewById(R.id.text)!!
        val logoImageView: ImageView = view.findViewById(R.id.icon)!!
        val sportListItemParent: View = view.findViewById(R.id.sportListItemParent)!!
    }
}