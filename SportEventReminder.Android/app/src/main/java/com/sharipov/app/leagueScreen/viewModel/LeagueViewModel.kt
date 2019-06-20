package com.sharipov.app.leagueScreen.viewModel

import android.app.Application
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import com.sharipov.app.db.entity.League
import com.sharipov.app.utils.CustomViewModel
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers

class LeagueViewModel(app: Application) : CustomViewModel(app) {

    private val mutableLiveData = MutableLiveData<ArrayList<League>>()
    private val list = ArrayList<League>()

    fun getLeagueList(): LiveData<ArrayList<League>> = mutableLiveData

    fun setOnSelectListener(league: League, checked: Boolean) {
        league.isWatched = checked
        list.forEach { if (it.id == league.id) it.isWatched = league.isWatched }
        interactor.saveLeagues(list)
    }

    init {
        compositeDisposable.add(interactor.getLeagues()
            .observeOn(AndroidSchedulers.mainThread())
            .subscribeOn(Schedulers.io())
            .subscribe(
                {
                    setItems(it)
                }, {
                    setItems(ArrayList())
                }
            )
        )
    }

    private fun setItems(it: ArrayList<League>) {
        list.clear()
        list.addAll(it)
        mutableLiveData.postValue(it)
    }
}