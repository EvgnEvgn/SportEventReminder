package com.sharipov.app.teamsScreen

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
import com.sharipov.app.teamsScreen.adapters.TeamsListAdapter
import com.sharipov.app.teamsScreen.viewModel.TeamsViewModel
import kotlinx.android.synthetic.main.teams_fragment_layout.*

class TeamsFragment : Fragment() {

    private lateinit var viewModel: TeamsViewModel
    private val adapter = TeamsListAdapter()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        viewModel = ViewModelProviders.of(this).get(TeamsViewModel::class.java)
        viewModel.getTeamList().observe(this, Observer {
            adapter.updateItems(it)
        })
    }

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? =
        inflater.inflate(R.layout.teams_fragment_layout, container, false)

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        initViews()
    }

    private fun initViews() {
        adapter.setOnSelectListener { team, isChecked ->
            viewModel.setOnSelectListener(team, isChecked)
        }

        teamsList.adapter = adapter
        teamsList.itemAnimator = DefaultItemAnimator()
        teamsList.layoutManager = LinearLayoutManager(context)
    }
}