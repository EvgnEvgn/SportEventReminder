package com.sharipov.app.leagueScreen.viewModel

import android.app.Application
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import com.sharipov.app.db.entity.League
import com.sharipov.app.di.Injector
import com.sharipov.app.interactors.IDataInteractor
import com.sharipov.app.utils.CustomViewModel
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers

class LeagueViewModel(app: Application) : CustomViewModel(app) {

    private val interactor: IDataInteractor = Injector.dataInteractor

    private val mutableSettingsLiveData = MutableLiveData<ArrayList<League>>()

    fun getLeagueList(): LiveData<ArrayList<League>> = mutableSettingsLiveData

    init {
        compositeDisposable.add(interactor.getLeagues()
            .observeOn(AndroidSchedulers.mainThread())
            .subscribeOn(Schedulers.io())
            .subscribe(
                {

                }, {

                }
            )
        )

        val list = ArrayList<League>()

        list.add(League(name = "America Cup", leagueLevel = 0, areaId = 0))
        list.add(League(name = "Argentina Cup", leagueLevel = 0, areaId = 0))
        list.add(League(name = "Russia Cup", leagueLevel = 0, areaId = 0))
        list.add(League(name = "Gorgia Cup", leagueLevel = 0, areaId = 0))

        mutableSettingsLiveData.postValue(list)

    }
}