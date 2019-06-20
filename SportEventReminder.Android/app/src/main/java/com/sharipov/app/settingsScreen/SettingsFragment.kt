package com.sharipov.app.settingsScreen

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProviders
import androidx.recyclerview.widget.DefaultItemAnimator
import androidx.recyclerview.widget.LinearLayoutManager
import com.sharipov.app.R
import com.sharipov.app.settingsScreen.adapters.SettingsListAdapter
import com.sharipov.app.settingsScreen.viewModel.SettingsViewModel
import kotlinx.android.synthetic.main.settings_fragment_layout.*

class SettingsFragment : Fragment() {

    private val adapter = SettingsListAdapter()

    private lateinit var viewModel: SettingsViewModel

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        viewModel = ViewModelProviders.of(this).get(SettingsViewModel::class.java)
        viewModel.getSettingsList().observe(this, Observer {
            adapter.updateItems(it)
        })
    }

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? =
        inflater.inflate(R.layout.settings_fragment_layout, container, false)

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        initViews()
    }

    private fun initViews() {
        adapter.setOnSelectListener { item, isChecked ->
            viewModel.setItemSelected(item,isChecked)
        }
        settingsList.adapter = adapter
        settingsList.itemAnimator = DefaultItemAnimator()
        settingsList.layoutManager = LinearLayoutManager(context)
    }
}