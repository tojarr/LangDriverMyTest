import { Component, OnInit } from '@angular/core';
import { EditDictionaryService } from './edit-dictionary.service';

@Component({
  selector: 'app-edit-dictionary',
  templateUrl: './edit-dictionary.component.html',
  styleUrls: ['./edit-dictionary.component.css']
})
export class EditDictionaryComponent implements OnInit {
  userId:string = JSON.parse(localStorage.getItem('User')).id;
  dictionary:any;
  inputWord:string = '';
  inputTranslate:string = '';
  statusDictionary:any;
  item:any;
  constructor(private editDictionaryService : EditDictionaryService) { }



  ngOnInit() {
    this.getDictionary();
  }

  getDictionary(){
    this.editDictionaryService.getDictionary(this.userId).subscribe(res => {this.dictionary = res;
      this.DictionaryToLocalStorage(this.dictionary);
    });
  }

  // AddWordToDictionary(){
  //   console.log('AddDictionary');
  //   this.editDictionaryService.AddWordToDictionary(this.userId, this.inputWord, this.inputTranslate).subscribe(res => this.dictionary = res);
  // }

  AddWordToDictionary()
  {
    if(this.dictionary.some(i => i.wordOrigin === this.inputWord) && this.inputTranslate !== ''){
      const body = {
        id: this.item.id,
        wordOrigin: this.inputWord,
        translate: this.inputTranslate,
        userId: this.item.userId
      };
      this.editDictionaryService.EditWord(body).subscribe(res => {
        if(res){
          this.dictionary = res;
          // let item = this.dictionary.find(i => i.wordOrigin === this.inputWord);
          // item.translate = this.inputTranslate;
          // item.wordOrigin = this.inputWord;
          this.inputTranslate = '';
          this.inputWord = '';
          this.DictionaryToLocalStorage(res);
        }
      });
    } else {
      const body = {
        wordOrigin: this.inputWord,
        translate: this.inputTranslate
      };

      this.editDictionaryService.AddWordToDictionary(this.userId, this.inputWord, this.inputTranslate).subscribe(res => {
        if(res){
          this.dictionary = res;
          //this.dictionary.push({wordOrigin: this.inputWord, translate: this.inputTranslate});
          this.inputTranslate = '';
          this.inputWord = '';
          this.DictionaryToLocalStorage(res);
        }
      });      
    }

    
  }

  editWord(item: any){
    this.item = item;
    this.inputWord = item.wordOrigin;
    this.inputTranslate = item.translate;
  }

  DeleteWord(word){
    console.log('DeleteWord');
    this.editDictionaryService.DeleteWord(word.userId, word.id).subscribe(res => {this.dictionary = res;
      this.DictionaryToLocalStorage(res);
    });
  }

  DictionaryToLocalStorage(dictionary:any){
    localStorage.setItem('Dictionary', JSON.stringify(dictionary));
    console.log(JSON.parse(localStorage.getItem('Dictionary')));
  }
}
