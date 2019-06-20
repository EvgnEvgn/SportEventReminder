package com.sharipov.app.utils

import com.google.gson.reflect.TypeToken

inline fun <reified T> genericType() = object : TypeToken<T>() {}.type