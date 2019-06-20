package com.sharipov.app.interactors

import com.sharipov.app.client.IReminderClient

class DataInteractor(private val reminderClient: IReminderClient) : IDataInteractor {

    override fun getAreas() = reminderClient.fetchAreas()

    override fun getTeams() = reminderClient.fetchTeams()

    override fun getLeagues() = reminderClient.fetchLeagues()

    override fun getMatches() = reminderClient.fetchMatch()
}