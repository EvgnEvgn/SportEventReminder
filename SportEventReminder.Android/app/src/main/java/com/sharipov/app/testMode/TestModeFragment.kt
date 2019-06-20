package com.sharipov.app.testMode

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProviders
import com.sharipov.app.R
import com.sharipov.app.testMode.viewModel.TestModeViewModel
import kotlinx.android.synthetic.main.test_mode_fragment_layout.*

class TestModeFragment : Fragment() {

    private lateinit var viewModel: TestModeViewModel

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        viewModel = ViewModelProviders.of(this).get(TestModeViewModel::class.java)
    }

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? =
        inflater.inflate(R.layout.test_mode_fragment_layout, container, false)

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        initViews()
    }

    private fun initViews() {
        clearDbBtn.setOnClickListener {
            viewModel.onClearDbBtn()
        }

        initDbBtn.setOnClickListener {
            viewModel.onInitBbBtn()
        }
    }
}