package com.sharipov.app.settingsScreen.viewModel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.sharipov.app.R
import com.sharipov.app.navDrawer.models.SportItem

class SettingsViewModel : ViewModel() {

    private val sportListLiveData: MutableLiveData<ArrayList<SportItem>> = MutableLiveData()
    private val screenNavigation: MutableLiveData<Int> = MutableLiveData()

    private val sportList = arrayListOf(SportItem("Футбол", R.mipmap.soccer_96, R.id.baseFragment))

    init {
        sportListLiveData.postValue(sportList)
    }

    fun getSportList(): LiveData<ArrayList<SportItem>> = sportListLiveData

    fun getScreenNavigation(): LiveData<Int> = screenNavigation

    fun onSportItemClick(item: SportItem) {
        screenNavigation.postValue(item.screenId)
    }

    fun onSettingsBtnClick() {

    }
}