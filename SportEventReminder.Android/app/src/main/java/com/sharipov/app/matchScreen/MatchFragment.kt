package com.sharipov.app.matchScreen

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
import com.sharipov.app.matchScreen.adapters.MatchListAdapter
import kotlinx.android.synthetic.main.match_fragment_layout.*

class MatchFragment : Fragment() {

    private lateinit var viewModel: MatchViewModel
    private val adapter = MatchListAdapter()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        viewModel = ViewModelProviders.of(this).get(MatchViewModel::class.java)
        viewModel.getMatchList().observe(this, Observer {
            adapter.updateItems(it)
        })
    }

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? =
        inflater.inflate(R.layout.match_fragment_layout, container, false)

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        initViews()
    }

    private fun initViews() {
        adapter.setOnSelectListener { match, isChecked ->
            viewModel.setOnSelectListener(match,isChecked)
        }

        matchRecyclerView.adapter = adapter
        matchRecyclerView.itemAnimator = DefaultItemAnimator()
        matchRecyclerView.layoutManager = LinearLayoutManager(context)
    }
}