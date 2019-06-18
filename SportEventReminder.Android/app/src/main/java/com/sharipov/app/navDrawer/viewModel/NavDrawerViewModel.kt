package com.sharipov.app.navDrawer.viewModel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.sharipov.app.R
import com.sharipov.app.navDrawer.models.SportItem
import com.sharipov.app.navDrawer.models.SubCategoryItem

class NavDrawerViewModel : ViewModel() {

    private val sportListLiveData: MutableLiveData<ArrayList<SportItem>> = MutableLiveData()
    private val screenNavigation: MutableLiveData<Int> = MutableLiveData()

    private val sportList = arrayListOf(
        SportItem(
            arrayListOf(
                SubCategoryItem("Commands", R.id.commandsFragment),
                SubCategoryItem("Leagues", R.id.leaguesFragment)
            ),
            R.mipmap.soccer_96,
            "Football",
            R.id.baseFragment
        )
    )

    init {
        sportListLiveData.postValue(sportList)
    }

    fun getSportList(): LiveData<ArrayList<SportItem>> = sportListLiveData

    fun getScreenNavigation(): LiveData<Int> = screenNavigation

    fun onSportItemClick(item: SportItem) {
        screenNavigation.postValue(item.screenId)
    }

    fun onSettingsBtnClick() {
        screenNavigation.postValue(R.id.settingsFragment)
    }

    fun onSubcategorySelect(subCategoryItem: SubCategoryItem) {
        screenNavigation.postValue(subCategoryItem.screenId)
    }
}