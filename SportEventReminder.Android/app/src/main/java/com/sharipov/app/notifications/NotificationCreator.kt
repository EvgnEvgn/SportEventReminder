package com.sharipov.app.notifications

import android.app.NotificationChannel
import android.app.NotificationManager
import android.content.Context
import android.content.Context.MODE_PRIVATE
import android.os.Build
import androidx.core.app.NotificationCompat
import androidx.core.app.NotificationManagerCompat
import com.sharipov.app.R

const val CHANNEL_ID = "Default"
const val CHANNEL_DESCRIPTION = "Channel for sport notifications"
const val NOTIFICATION_ID_KEY = "notification_id_key"
const val NOTIFICATION_SHARED_PREF = "notification_shared_pref"

class NotificationCreator {

    fun create(context: Context, title: String, text: String) {
        createNotificationChannel(context)

        val notification = NotificationCompat.Builder(context, CHANNEL_ID)
            .setSmallIcon(R.mipmap.ic_launcher)
            .setContentTitle(title)
            .setAutoCancel(true)
            .setContentText(text)
            .setPriority(NotificationCompat.PRIORITY_DEFAULT).build()

        NotificationManagerCompat.from(context).notify(
            getNextNotificationId(context),
            notification
        )
    }

    private fun createNotificationChannel(context: Context) {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            val name = CHANNEL_ID
            val importance = NotificationManager.IMPORTANCE_DEFAULT
            val channel = NotificationChannel(CHANNEL_ID, name, importance).apply {
                description = CHANNEL_DESCRIPTION
            }

            val notificationManager: NotificationManager =
                context.getSystemService(Context.NOTIFICATION_SERVICE) as NotificationManager
            notificationManager.createNotificationChannel(channel)
        }
    }

    private fun getNextNotificationId(context: Context): Int {
        val sp = context.getSharedPreferences(NOTIFICATION_SHARED_PREF, MODE_PRIVATE)
        val id = sp.getInt(NOTIFICATION_ID_KEY, 0)
        sp.edit().putInt(NOTIFICATION_ID_KEY, (id + 1) % Int.MAX_VALUE).apply()

        return id
    }
}