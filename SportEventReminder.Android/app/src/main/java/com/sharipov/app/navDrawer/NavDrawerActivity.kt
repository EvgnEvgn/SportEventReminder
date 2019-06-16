package com.sharipov.app.navDrawer

import android.os.Bundle
import androidx.appcompat.app.ActionBarDrawerToggle
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.widget.Toolbar
import androidx.drawerlayout.widget.DrawerLayout
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProviders
import androidx.recyclerview.widget.DefaultItemAnimator
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.navigation.NavigationView
import com.sharipov.app.R
import com.sharipov.app.navDrawer.viewModel.NavDrawerViewModel

class NavDrawerActivity : AppCompatActivity() {

    private lateinit var viewModel: NavDrawerViewModel
    private lateinit var sportListView: RecyclerView
    private val sportListAdapter: SportListAdapter = SportListAdapter()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_nav_drawer)
        initViews()
        initViewModel()
    }

    private fun initViewModel() {
        viewModel = ViewModelProviders.of(this).get(NavDrawerViewModel::class.java)
        viewModel.getSportList().observe(this, Observer {
            sportListAdapter.updateItems(it)
        })
    }

    private fun initViews() {
        val toolbar: Toolbar = findViewById(R.id.toolbar)
        setSupportActionBar(toolbar)

        val drawerLayout: DrawerLayout = findViewById(R.id.drawer_layout)
        val navView: NavigationView = findViewById(R.id.nav_view)
        val toggle = ActionBarDrawerToggle(
            this, drawerLayout, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close
        )
        drawerLayout.addDrawerListener(toggle)
        toggle.syncState()

        initSportListView(navView)
    }

    private fun initSportListView(navView: NavigationView) {
        sportListView = navView.getHeaderView(0).findViewById(R.id.sportRecyclerView)
        sportListView.layoutManager = LinearLayoutManager(this)
        sportListView.itemAnimator = DefaultItemAnimator()
        sportListView.adapter = sportListAdapter
    }
}
