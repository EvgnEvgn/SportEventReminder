package com.sharipov.app.teamsScreen.viewModel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.sharipov.app.db.entity.Team

class TeamsViewModel : ViewModel() {

    private val mutableSettingsLiveData = MutableLiveData<ArrayList<Team>>()

    fun getTeamList(): LiveData<ArrayList<Team>> = mutableSettingsLiveData

    init {
        val list = ArrayList<Team>()

        list.add(Team(name = "CSKA 1948 Sofia", shortName = "", areaId = 1, teamTag = "Bog"))
        list.add(Team(name = "Strumska Slava", shortName = "", areaId = 1, teamTag = "Bog"))
        list.add(Team(name = "Orenburg", shortName = "", areaId = 1, teamTag = "Ros"))
        list.add(Team(name = "CHFR", shortName = "", areaId = 1, teamTag = "Rum"))

        mutableSettingsLiveData.postValue(list)
    }
}