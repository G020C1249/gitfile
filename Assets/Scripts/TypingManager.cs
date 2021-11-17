using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//画面にあるテキストの文字を変更
public class TypingManager : MonoBehaviour
{   
    
        //画面にあるテキストを持ってくる
        public Text fText; //ふりがな用のテキスト
        public Text qText; //問題用のテキスト
        public Text aText; //答え用のテキスト
        public Image sampleImage; //画像用
        public int scoreCnt;
    
        //問題を用意しておく
        public string[] questions; 
        public string[] furigana; 
        public string[] answers; 
        public Sprite[] dishes;


        //何番目か指定するためのstring
        private string _fString;
        private string _qString;
        private string _aString;
    

        //何番目の問題か
        private int _qNum;

        //問題の何文字目か
        private int _aNum;
        
        
        //ゲームを始めたときに１度だけ呼ばれるもの
        void Start()
        {
            //問題を出す
            Output();
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(_aString[_aNum].ToString()))
            {
                //正解
                Correct();   

                //最期の文字に正解したら
                if (_aNum >= _aString.Length) 
                {
                    //問題を変える
                    Output();
                    scoreCnt++;
                } 
            }
            else if (Input.anyKeyDown)
            {
                //不正解
                Miss();
            }
        }      
    
        //問題を出すための関数
        void Output()
        {
            //0番目の文字に戻す
            _aNum = 0;

            //_qNumに０~問題数までのランダムな数字を１つ入れる
            _qNum = Random.Range(0,questions.Length);

            _fString = furigana[_qNum];
            _qString = questions[_qNum];
            _aString = answers[_qNum];
            sampleImage.sprite = dishes[_qNum];
    
            //文字を変更する
            fText.text = _fString;
            qText.text = _qString;
            aText.text = _aString;
            //dImage.image = _dString; 
        }

        //正解したときの処理
         void Correct()
        {     
            _aNum++;
            aText.text = "<color=#6A6A6A>" + _aString.Substring(0,_aNum) + "</color>" + _aString.Substring(_aNum);
            Debug.Log(_aNum);
        }


    //間違い用の関数
        void Miss()
        {    
            aText.text = "<color=#6A6A6A>"+ _aString.Substring(0,_aNum) + "</color>" 
            + "<color=#D91818>" + _aString.Substring(_aNum,1) + "</color>" 
            + _aString.Substring(_aNum+1);
            Debug.Log(_aNum);
        } 
    }      
