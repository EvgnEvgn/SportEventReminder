package com.sharipov.app.navDrawer.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.DefaultItemAnimator
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.sharipov.app.R
import com.sharipov.app.navDrawer.models.SportItem
import com.sharipov.app.navDrawer.models.SubCategoryItem

class SportListAdapter : RecyclerView.Adapter<SportListAdapter.ViewHolder>() {

    private val list = ArrayList<SportItem>()
    private lateinit var listener: (SportItem) -> Unit
    private lateinit var subcategoryListener: (SubCategoryItem) -> Unit

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val layoutInflater = LayoutInflater.from(parent.context)
        return ViewHolder(
            layoutInflater.inflate(
                R.layout.sport_list_item,
                parent,
                false
            )
        )
    }

    override fun getItemCount(): Int = list.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item: SportItem = list[position]

        holder.logoImageView.setImageResource(item.icon)
        holder.textTv.text = item.name

        holder.textTv.setOnClickListener(onClickListener(item))
        holder.logoImageView.setOnClickListener(onClickListener(item))
        holder.sportListItemParent.setOnClickListener(onClickListener(item))

        val subcategoryAdapter = SubcategoryAdapter()
        holder.subcategoriesList.adapter = subcategoryAdapter
        holder.subcategoriesList.layoutManager = LinearLayoutManager(holder.textTv.context)
        holder.subcategoriesList.itemAnimator = DefaultItemAnimator()

        subcategoryAdapter.setOnClickListener {
            subcategoryListener?.invoke(it)
        }

        subcategoryAdapter.updateItems(item.subcategories)
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

    fun setSubcategoryOnClickListener(listener: (SubCategoryItem) -> Unit) {
        this.subcategoryListener = listener
    }

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val textTv: TextView = view.findViewById(R.id.text)!!
        val logoImageView: ImageView = view.findViewById(R.id.icon)!!
        val sportListItemParent: View = view.findViewById(R.id.sportListItemParent)!!
        val subcategoriesList: RecyclerView = view.findViewById(R.id.subcategoriesList)!!
    }
}