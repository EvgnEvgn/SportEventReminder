package com.sharipov.app.db.entity

import androidx.annotation.NonNull
import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "Season")
class Season {

    @NonNull
    @PrimaryKey(autoGenerate = false)
    var id: Long? = null

}