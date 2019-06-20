package com.sharipov.app.leagueScreen

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
import com.sharipov.app.leagueScreen.adapters.LeagueListAdapter
import com.sharipov.app.leagueScreen.viewModel.LeagueViewModel
import kotlinx.android.synthetic.main.league_fragment_layout.*

class LeagueFragment : Fragment() {

    private lateinit var viewModel: LeagueViewModel
    private val adapter = LeagueListAdapter()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        viewModel = ViewModelProviders.of(this).get(LeagueViewModel::class.java)
        viewModel.getLeagueList().observe(this, Observer {
            adapter.updateItems(it)
        })
    }

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? =
        inflater.inflate(R.layout.league_fragment_layout, container, false)

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        initViews()
    }

    private fun initViews() {
        adapter.setOnSelectListener { league, isChecked ->
            viewModel.setOnSelectListener(league, isChecked)
        }

        leaguesList.adapter = adapter
        leaguesList.itemAnimator = DefaultItemAnimator()
        leaguesList.layoutManager = LinearLayoutManager(context)
    }
}