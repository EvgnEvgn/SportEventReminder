package com.sharipov.app.di

import com.sharipov.app.BASE_URL
import com.sharipov.app.client.IReminderClient
import com.sharipov.app.client.ReminderClient
import com.sharipov.app.interactors.DataInteractor
import com.sharipov.app.interactors.IDataInteractor
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object Injector {

    val retrofit: Retrofit = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(GsonConverterFactory.create())
        .build()


    val reminderClient: IReminderClient = ReminderClient()

    val dataInteractor:  IDataInteractor by lazy { DataInteractor(reminderClient) }


}