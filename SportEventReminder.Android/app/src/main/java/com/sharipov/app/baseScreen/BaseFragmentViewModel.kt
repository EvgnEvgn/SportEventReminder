package com.sharipov.app.baseScreen

import android.util.Log
import androidx.lifecycle.ViewModel
import com.sharipov.app.App.Companion.DB
import com.sharipov.app.db.dao.AreaDao
import com.sharipov.app.db.entity.Area
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch

class BaseFragmentViewModel : ViewModel() {

    companion object {
        const val TAG = "sharipov"
    }

    fun testDbOnClick() {
        GlobalScope.launch {
            val areaDao: AreaDao = DB.areaDao()

            areaDao.getAll().forEach {
                areaDao.delete(it)
            }

            areaDao.insertAll(
                Area(name = "area1", parentArea = "parent1"),
                Area(name = "area2", parentArea = "parent2")
            )

            val result = areaDao.getAll()
            Log.d(TAG, "" + (result.size == 2))
        }
    }
}