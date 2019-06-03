package com.sharipov.app.db.entity

import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "Team")
class Team {

    @PrimaryKey(autoGenerate = true)
    var id: Long? = null

}