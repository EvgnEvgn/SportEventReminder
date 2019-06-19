package com.sharipov.app.leagueScreen.viewModel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.sharipov.app.db.entity.League

class LeagueViewModel : ViewModel() {

    private val mutableSettingsLiveData = MutableLiveData<ArrayList<League>>()

    fun getLeagueList(): LiveData<ArrayList<League>> = mutableSettingsLiveData

    init {
        val list = ArrayList<League>()

        list.add(League(name = "America Cup", leagueLevel = 0, areaId = 0))
        list.add(League(name = "Argentina Cup", leagueLevel = 0, areaId = 0))
        list.add(League(name = "Russia Cup", leagueLevel = 0, areaId = 0))
        list.add(League(name = "Gorgia Cup", leagueLevel = 0, areaId = 0))

        mutableSettingsLiveData.postValue(list)
    }
}