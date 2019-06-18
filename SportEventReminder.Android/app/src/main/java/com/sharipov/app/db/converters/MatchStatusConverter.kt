package com.sharipov.app.db.converters

import androidx.room.TypeConverter
import com.google.gson.Gson
import com.sharipov.app.db.entity.MatchStatus

class MatchStatusConverter {

    @TypeConverter
    fun toStatus(value: String): MatchStatus = Gson().fromJson(value, MatchStatus::class.java)

    @TypeConverter
    fun toString(categories: MatchStatus): String = Gson().toJson(categories)

}