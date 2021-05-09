import {Component, OnInit, Inject, ViewChild, ElementRef} from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Device } from "./device.interface";

@Component({
  selector: 'dov',
  templateUrl: './deviceoverview.component.html',
  styleUrls: ['./deviceoverview.component.css']
})
export class DeviceoverviewComponent implements OnInit {
  //--------------------------------------------------------------------------------------------------------------------
  //----  VARIABLES
  //--------  FILE INPUT
  @ViewChild('deviceFileInput', { read: ElementRef, static: true }) FileInput = "";
  //--------  DEVICE OVERVIEW LIST
  deviceList: Array<Device> = [];
  //--------------------------------------------------------------------------------------------------------------------
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http.get<Device[]>( baseUrl + "api/Inventory/GetDevices").subscribe(data => this.deviceList = data)
  }
  //--------------------------------------------------------------------------------------------------------------------
  //----  ON INIT
  ngOnInit() {

  }
  //--------------------------------------------------------------------------------------------------------------------
  //---- FILE SELECT METHOD
  onFileSelect(event) {
    // Prepped Function to accept multiple files
    Array.prototype.forEach.call(event.target.files, file => {
      // @ts-ignore
      let fileReader: FileReader = new FileReader();
      fileReader.readAsText(file);
      fileReader.onload = () => {
        let fileContent = JSON.parse(fileReader.result.toString());
        fileContent.devices.forEach( device => {
          this.InsertDevice(device);
        })
      };
      fileReader.onerror = (error) => {
        console.log(error);
      }
    })
    //reset file input value
    //if i dont do this, it will not "upload" the same file twice back to back, since the input does not change
    this.FileInput = "";
  }
  //--------------------------------------------------------------------------------------------------------------------
  //----  UPLOAD METHOD
  InsertDevice(device: Device){
    this.http.post(window.location.origin + "/api/Inventory/SetDevice", JSON.stringify(device), {
      headers: new HttpHeaders().set("Content-Type", "application/json"),
      responseType: "text"
    }).subscribe(data => {
      let responseData = JSON.parse(data);
      if( responseData.success ){
        if(!this.deviceList.find(x => x.id == responseData.device.id && x.name == responseData.device.name)){
          this.deviceList.push(responseData.device);
        }
      }
      else {
        alert(responseData.exception)
        console.log(responseData.exceptionText)
      }
    },
    error => {
      alert(error);
    })
  }
  //--------------------------------------------------------------------------------------------------------------------
  //----  DELETE DEVICE METHOD
  onClickDelete(device: Device){
    this.http.post(window.location.origin + "/api/Inventory/DeleteDevice", JSON.stringify(device), {
      headers: new HttpHeaders().set("Content-Type", "application/json"),
      responseType: "text"
    }).subscribe(data => {
        let responseData = JSON.parse(data);
        if( responseData.success ){
          if(this.deviceList.find(x => x.id == responseData.device.id && x.name == responseData.device.name)){
            this.deviceList.splice( this.deviceList.indexOf( device ), 1);
          }
        }
        else {
          alert(responseData.exception)
          console.log(responseData.exceptionText)
        }
      },
      error => {
        alert(error);
      })
  }
  //--------------------------------------------------------------------------------------------------------------------
}
