package com.sharipov.app.navDrawer.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.sharipov.app.R
import com.sharipov.app.navDrawer.models.SubCategoryItem

class SubcategoryAdapter : RecyclerView.Adapter<SubcategoryAdapter.ViewHolder>() {

    private val list = ArrayList<SubCategoryItem>()
    private lateinit var listener: (SubCategoryItem) -> Unit

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val layoutInflater = LayoutInflater.from(parent.context)
        return ViewHolder(
            layoutInflater.inflate(
                R.layout.subcategory_list_item,
                parent,
                false
            )
        )
    }

    override fun getItemCount(): Int = list.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item: SubCategoryItem = list[position]

        holder.textTv.text = item.name
        holder.textTv.setOnClickListener(onClickListener(item))
        holder.subcategoryListItemParent.setOnClickListener(onClickListener(item))
    }

    private fun onClickListener(item: SubCategoryItem): (View) -> Unit = {
        listener.invoke(item)
    }

    fun updateItems(it: ArrayList<SubCategoryItem>) {
        list.clear()
        list.addAll(it)
        notifyDataSetChanged()
    }

    fun setOnClickListener(listener: (SubCategoryItem) -> Unit) {
        this.listener = listener
    }

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val textTv: TextView = view.findViewById(R.id.text)!!
        val subcategoryListItemParent: View = view.findViewById(R.id.subcategoryListItemParent)!!
    }
}