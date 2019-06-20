package com.sharipov.app.settingsScreen.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.appcompat.widget.SwitchCompat
import androidx.recyclerview.widget.RecyclerView
import com.sharipov.app.R
import com.sharipov.app.settingsScreen.models.SettingsItem

class SettingsListAdapter : RecyclerView.Adapter<SettingsListAdapter.ViewHolder>() {

    private var onSelectListener: ((SettingsItem, Boolean) -> Unit)? = null

    private val list = ArrayList<SettingsItem>()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val layoutInflater = LayoutInflater.from(parent.context)
        return ViewHolder(
            layoutInflater.inflate(
                R.layout.settings_list_item,
                parent,
                false
            )
        )
    }

    fun setOnSelectListener(listener: (SettingsItem, Boolean) -> Unit) {
        this.onSelectListener = listener
    }

    override fun getItemCount(): Int = list.size

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item: SettingsItem = list[position]

        holder.logoImageView.setImageResource(item.icon)
        holder.textTv.text = item.name
        holder.chip.isChecked = item.isChecked

        holder.chip.setOnCheckedChangeListener { _, isChecked ->
            run {
                onSelectListener?.invoke(item, isChecked)
            }
        }
    }

    fun updateItems(it: ArrayList<SettingsItem>) {
        list.clear()
        list.addAll(it)
        notifyDataSetChanged()
    }

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val textTv: TextView = view.findViewById(R.id.text)!!
        val logoImageView: ImageView = view.findViewById(R.id.icon)!!
        val chip: SwitchCompat = view.findViewById(R.id.chip)!!
    }
}