package com.sharipov.app.db.entity

import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "Season")
class Season {

    @PrimaryKey(autoGenerate = true)
    var id: Long? = null

}