package com.sharipov.app.settingsScreen.viewModel

import android.app.Application
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import com.sharipov.app.settingsScreen.SettingsStorage
import com.sharipov.app.settingsScreen.models.SettingsItem
import com.sharipov.app.utils.CustomViewModel

class SettingsViewModel(app: Application) : CustomViewModel(app) {

    private val settingsStorage = SettingsStorage(app)

    private val mutableSettingsLiveData = MutableLiveData<ArrayList<SettingsItem>>()

    init {
        mutableSettingsLiveData.postValue(settingsStorage.settingsList)
    }

    fun getSettingsList(): LiveData<ArrayList<SettingsItem>> = mutableSettingsLiveData

    fun setItemSelected(item: SettingsItem, isChecked: Boolean) {
        item.isChecked = isChecked
        settingsStorage.settingsList.forEach { if (it.name == item.name) it.isChecked = item.isChecked }
        settingsStorage.saveList()
    }
}