package com.sharipov.app.navDrawer.viewModel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.sharipov.app.R
import com.sharipov.app.navDrawer.models.SportItem

/**
 * TODO
 */
class NavDrawerViewModel : ViewModel() {

    private val sportListLiveData: MutableLiveData<ArrayList<SportItem>> = MutableLiveData()
    private val sportList = arrayListOf(SportItem("Футбол", R.mipmap.soccer_96))

    init {
        sportListLiveData.postValue(sportList)
    }

    fun getSportList(): LiveData<ArrayList<SportItem>> = sportListLiveData

}