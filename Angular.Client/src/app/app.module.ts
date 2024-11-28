import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing';
import { AppComponent } from './app.component';
import { SharedModule } from './modules/sharedModule';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule, // Import SharedModule here
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
