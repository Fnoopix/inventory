import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { Device } from "../deviceoverview/device.interface";

@Component({
  selector: 'ddts',
  templateUrl: './devicedetails.component.html',
  styleUrls: ['./devicedetails.component.css']
})
export class DevicedetailsComponent implements OnInit {
  //--------------------------------------------------------------------------------------------------------------------
  //----  VARIABLES
  //--------  DEVICE
  device: Device;
  //--------------------------------------------------------------------------------------------------------------------
  //----  CONSTRUCTOR
  constructor(router: Router ) {
    // GET given Device and set to local variable for use in view
    this.device = router.getCurrentNavigation().extras.state as Device;
  }
  //--------------------------------------------------------------------------------------------------------------------
  //----  ON INIT
  ngOnInit() {

  }
  //--------------------------------------------------------------------------------------------------------------------
}
