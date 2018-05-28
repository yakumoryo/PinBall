using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FripperController : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;



	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow)  && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}

	public void GetMyLeftButtonDown() {
		if (tag == "LeftFripperTag"){
			SetAngle (this.flickAngle);
		}
	}

	//左ボタンを離した場合の処理（追加）
	public void GetMyLeftButtonUp() {
		if (tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
	}

	//右ボタンを押し続けた場合の処理（追加）
	public void GetMyRightButtonDown() {
		if (tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
	}
	//右ボタンを離した場合の処理（追加）
	public void GetMyRightButtonUp() {
		if (tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
	}
}