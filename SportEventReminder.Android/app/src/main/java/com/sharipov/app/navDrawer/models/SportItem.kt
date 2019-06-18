package com.sharipov.app.navDrawer.models

import androidx.annotation.DrawableRes

class SportItem(
    val subcategories: ArrayList<SubCategoryItem> = ArrayList(),
    @DrawableRes val icon: Int,
    name: String,
    screenId: Int
) : CategoryItem(name, screenId)