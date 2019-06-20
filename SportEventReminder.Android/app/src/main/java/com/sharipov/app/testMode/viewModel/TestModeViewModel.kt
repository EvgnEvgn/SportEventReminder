package com.sharipov.app.testMode.viewModel

import androidx.lifecycle.ViewModel
import com.sharipov.app.di.Injector

class TestModeViewModel : ViewModel() {

    fun onInitBbBtn() {
        Injector.reminderClient.clearAll()
        Injector.reminderClient.initDefaultValues()
    }

    fun onClearDbBtn() {
        Injector.reminderClient.clearAll()
    }
}
