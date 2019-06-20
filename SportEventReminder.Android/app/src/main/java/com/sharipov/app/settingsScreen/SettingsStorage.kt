package com.sharipov.app.settingsScreen

import android.content.Context
import com.google.gson.Gson
import com.sharipov.app.R
import com.sharipov.app.settingsScreen.models.SettingsItem
import com.sharipov.app.utils.genericType


private const val SHARED_PREF_NAME = "settings"
private const val SHARED_PREF_KEY = "list_key"

class SettingsStorage(context: Context) {

    private val sp = context.getSharedPreferences(SHARED_PREF_NAME, Context.MODE_PRIVATE)

    var settingsList = arrayListOf(
        SettingsItem("Remind before start (30 min.)", R.drawable.ic_event_available_black_24dp, false),
        SettingsItem("Match beginning", R.drawable.ic_notifications_black_24dp, false)
    )

    init {
        val json = sp?.getString(SHARED_PREF_KEY, "")
        if (json!!.isEmpty()) {
            saveList()
        } else {
            settingsList = Gson().fromJson(json, genericType<ArrayList<SettingsItem>>())
        }
    }

    fun saveList() {
        sp.edit()
            .putString(SHARED_PREF_KEY, Gson().toJson(settingsList))
            .apply()
    }
}

