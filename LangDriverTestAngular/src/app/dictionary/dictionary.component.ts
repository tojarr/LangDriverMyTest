import { Component, OnInit } from '@angular/core';
import { DictionaryService } from './dictionary.service';

@Component({
  selector: 'app-dictionary',
  templateUrl: './dictionary.component.html',
  styleUrls: ['./dictionary.component.css']
})
export class DictionaryComponent implements OnInit {

  dictionary: any
  countOfWords: number = 0;
  word:string = '';
  translate:string = '';
  index:number = 0;
  indexHelp:number = 0;

  constructor(dictionaryService : DictionaryService) { }

  ngOnInit() {
    this.GetDictionary();
  }

  GetDictionary(){
    this.dictionary = JSON.parse(localStorage.getItem('Dictionary'));
    this.countOfWords = this.dictionary.length;
    this.SetWord();
    //console.log(this.dictionary);
  }

  SetWord(){
    this.word = this.dictionary[this.index].wordOrigin;
  }

  nextWord(){
    this.index++;
    if(this.index >= this.countOfWords){this.index = 0;}
    this.word = this.dictionary[this.index].wordOrigin;
    this.translate = '';
    this.indexHelp = 0;
  }

  getTranslate(){
    this.translate = this.dictionary[this.index].translate;
    this.indexHelp = this.translate.length;
  }

  help(){
    if(this.indexHelp < this.dictionary[this.index].translate.length){
      this.translate += this.dictionary[this.index].translate[this.indexHelp];
      this.indexHelp++;
    }
  }
}
