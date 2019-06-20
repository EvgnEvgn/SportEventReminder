package com.sharipov.app.utils

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import com.sharipov.app.di.Injector
import com.sharipov.app.interactors.IDataInteractor
import io.reactivex.disposables.CompositeDisposable

abstract class CustomViewModel(application: Application) : AndroidViewModel(application) {

    open val interactor: IDataInteractor = Injector.dataInteractor
    open val compositeDisposable = CompositeDisposable()

    override fun onCleared() {
        compositeDisposable.clear()
        super.onCleared()
    }
}