package com.sharipov.app.reminder

import android.app.IntentService
import android.content.Intent
import android.util.Log
import com.sharipov.app.App
import com.sharipov.app.db.entity.Match
import com.sharipov.app.notifications.NotificationCreator
import com.sharipov.app.settingsScreen.SettingsStorage
import java.util.*

private const val NOTIFICATION_TITLE = "Sport Reminder"
private const val MIN_30 = 30 * 60 * 1000

class IntervalReminderService : IntentService("IntervalReminderService") {

    override fun onHandleIntent(intent: Intent?) {
        val settingsStorage = SettingsStorage(baseContext)

        val isAfterIntervalRemind = settingsStorage.settingsList[0].isChecked
        val isNowRemind = settingsStorage.settingsList[1].isChecked
        if (!isAfterIntervalRemind && !isNowRemind) return

        val timeNow = Date().time
        App.DB.matchDao().getAll().forEach {
            if (it.isWatched) {
                if (isAfterIntervalRemind && it.startDate >= timeNow + MIN_30 - 30 * 1000 && it.startDate <= timeNow + MIN_30 + 30 * 1000) {
                    Log.d("sharipov", "isAfterIntervalRemind !")
                    NotificationCreator().create(
                        baseContext,
                        NOTIFICATION_TITLE,
                        "Now: " + getMatchString(it)
                    )
                }

                if (isNowRemind && it.startDate >= timeNow - 30 * 1000 && it.startDate <= timeNow + 30 * 1000) {
                    Log.d("sharipov", "isNowRemind")
                    NotificationCreator().create(
                        baseContext,
                        NOTIFICATION_TITLE,
                        "In thirty minutes: " + getMatchString(it)
                    )
                }
            }
        }
    }

    private fun getMatchString(match: Match): String {
        var teamHome = ""
        var teamAway = ""
        App.DB.teamDao().getAll().forEach {
            if (match.awayTeamId == it.id) {
                teamAway = it.name!!
            }
            if (match.homeTeamId == it.id) {
                teamHome = it.name!!
            }
        }

        return "$teamHome  VS  $teamAway"
    }
}
