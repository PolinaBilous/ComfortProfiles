import { Component, OnInit } from '@angular/core';
import { Service } from 'src/logic/service.service';
import { StaticInfo } from 'src/logic/static-info.model';
import { CoffeeLog } from 'src/logic/coffee-log.model';

@Component({
  selector: 'app-api-test',
  templateUrl: './api-test.component.html',
  styleUrls: ['./api-test.component.css']
})
export class ApiTestComponent implements OnInit {

  constructor(private service: Service) { }

  ngOnInit() {
  }

  getStaticInfoTest() {
    this.service.getStaticInfo().subscribe(res => console.log(res));
  }

  getChairTypesTest() {
    this.service.getChairTypes().subscribe(res => console.log(res));
  }

  getTableTypesTest() {
    this.service.getTableTypes().subscribe(res => console.log(res));
  }

  getWaterTypesTest() {
    this.service.getWaterTypes().subscribe(res => console.log(res));
  }

  getMattressTypesTest() {
    this.service.getMattressTypes().subscribe(res => console.log(res));
  }

  getCoffeeTypesTest() {
    this.service.getCoffeeTypes().subscribe(res => console.log(res));
  }

  getHowOftenTest() {
    this.service.getHowOftens().subscribe(res => console.log(res));
  }

  makeCupOfCoffeeIfNeededTest(){
    this.service.makeCupOfCoffeeIfNeeded().subscribe(res => console.log(res));
  }

  addStaticInfoTest() {
    let staticInfo : StaticInfo = new StaticInfo();
    staticInfo.Allergens = "test";
    staticInfo.ChairTypeId = 1;
    staticInfo.ClothingSize = 1;
    staticInfo.FruitPreferences = "test";
    staticInfo.KindOfCoffee = "test";
    staticInfo.KindOfTea = "test";
    staticInfo.MattressTypeId = 1;
    staticInfo.MusicalPreferences = "test";
    staticInfo.ShoeSize = 1;
    staticInfo.TableTypeId = 1;
    staticInfo.WaterTypeId = 1;

    this.service.addStaticInfo(staticInfo).subscribe(result => console.log(result));
  }

  updateStaticInfoTest() {
    let staticInfo : StaticInfo = new StaticInfo();
    staticInfo.Allergens = "test1";
    staticInfo.ChairTypeId = 1;
    staticInfo.ClothingSize = 1;
    staticInfo.FruitPreferences = "test1";
    staticInfo.KindOfCoffee = "test";
    staticInfo.KindOfTea = "test";
    staticInfo.MattressTypeId = 1;
    staticInfo.MusicalPreferences = "test";
    staticInfo.ShoeSize = 1;
    staticInfo.TableTypeId = 1;
    staticInfo.WaterTypeId = 1;

    this.service.updateStaticInfo(staticInfo).subscribe(result => console.log(result));
  }

  registerUser(){
    this.service.registerUser("test134", "test134", "test134").subscribe(result => console.log(result));
  }

  loginUser(){
    this.service.loginUser("polina.bilous@nure.ua", "Polina99").subscribe(result => console.log(result));
  }

  addCoffeDeviceTest() {
    this.service.addCoffeDevice().subscribe(res => console.log(res));
  }

  getCoffeDeviceStateTest(){
    this.service.getCoffeeDeviceState().subscribe(res => console.log(res));
  }

  makeCupOfCoffeeTest(){
    let coffeeLog : CoffeeLog = new CoffeeLog();
    coffeeLog.CoffeeTypeId = "2B249754-8876-4339-A6B8-213C1788B8CA";
    coffeeLog.HowOftenId = 1;
    coffeeLog.DateTime = "2018-10-21T21:42:32.445Z";

    this.service.makeCupOfCoffee(coffeeLog).subscribe(res => console.log(res));
  }
}
