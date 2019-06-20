package com.sharipov.app.db.entity

import androidx.room.ColumnInfo

abstract class WatchedEntity {

    @ColumnInfo(name = "isWatched") var isWatched: Boolean = false

}