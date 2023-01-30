# CinemaCameraJP
CinemaSceneのCameraを日本風にしたリポジトリ
#CinemasceneのCameraを使ってマリオ６４やゼルダの伝説風のカメラを実装する。
左右に移動するときはキャラクターを追尾し、前進する時にカメラの向いている方に移動するコード。
    void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
    上記の部分でplayerのカメラの向いている方向に進むというコードが書かれている。
    
