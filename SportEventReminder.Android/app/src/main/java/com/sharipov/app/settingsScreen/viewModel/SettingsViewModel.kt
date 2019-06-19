package com.sharipov.app.settingsScreen.viewModel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.sharipov.app.R
import com.sharipov.app.settingsScreen.models.SettingsItem

class SettingsViewModel : ViewModel() {

    private val mutableSettingsLiveData = MutableLiveData<ArrayList<SettingsItem>>()

    private val settingsList = arrayListOf(
        SettingsItem("Remind before start (30 min.)", R.drawable.ic_event_available_black_24dp),
        SettingsItem("Match beginning", R.drawable.ic_notifications_black_24dp, true)
    )

    fun getSettingsList(): LiveData<ArrayList<SettingsItem>> = mutableSettingsLiveData

    init {
        mutableSettingsLiveData.postValue(settingsList)
    }
}