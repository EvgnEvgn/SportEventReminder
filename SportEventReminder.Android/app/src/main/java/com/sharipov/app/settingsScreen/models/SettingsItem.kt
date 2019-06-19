package com.sharipov.app.settingsScreen.models

import androidx.annotation.DrawableRes

class SettingsItem(
    val name: String,
    @DrawableRes val icon: Int,
    var isChecked: Boolean = false
)