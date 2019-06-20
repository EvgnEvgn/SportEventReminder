package com.sharipov.app.testMode.viewModel

import androidx.lifecycle.ViewModel
import com.sharipov.app.di.Injector

class TestModeViewModel : ViewModel() {

    init {

    }

    fun onInitBbBtn() {
        Injector.reminderClient.initDefaultValues()
    }

    fun onClearDbBtn() {
        Injector.reminderClient.clearAll()
    }
}
