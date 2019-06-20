package com.sharipov.app.interactors

import com.sharipov.app.client.IReminderClient
import com.sharipov.app.db.entity.Area
import com.sharipov.app.db.entity.League
import com.sharipov.app.db.entity.Match
import com.sharipov.app.db.entity.Team

class DataInteractor(private val reminderClient: IReminderClient) : IDataInteractor {

    override fun getAreas() = reminderClient.fetchAreas()

    override fun getTeams() = reminderClient.fetchTeams()

    override fun getLeagues() = reminderClient.fetchLeagues()

    override fun getMatches() = reminderClient.fetchMatch()

    override fun saveAreas(items: ArrayList<Area>) {
        reminderClient.saveAreas(items)
    }

    override fun saveTeams(items: ArrayList<Team>) {
        reminderClient.saveTeams(items)
    }

    override fun saveLeagues(items: ArrayList<League>) {
        reminderClient.saveLeagues(items)
    }

    override fun saveMatches(items: ArrayList<Match>) {
        reminderClient.saveMatches(items)
    }
}