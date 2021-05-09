import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { DeviceoverviewComponent} from "./deviceoverview/deviceoverview.component";
import { DevicedetailsComponent } from "./devicedetails/devicedetails.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DeviceoverviewComponent,
    DevicedetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: DeviceoverviewComponent, pathMatch: 'full' },
      { path: 'detail', component: DevicedetailsComponent, pathMatch: 'full'},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
