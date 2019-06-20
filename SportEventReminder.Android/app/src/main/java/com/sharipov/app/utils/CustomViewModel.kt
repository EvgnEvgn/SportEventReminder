package com.sharipov.app.utils

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import io.reactivex.disposables.CompositeDisposable

abstract class CustomViewModel(application: Application) : AndroidViewModel(application) {

    open val compositeDisposable = CompositeDisposable()

    override fun onCleared() {
        compositeDisposable.clear()
        super.onCleared()
    }
}