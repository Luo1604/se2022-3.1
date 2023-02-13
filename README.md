# se2022- Nhóm 3.1: Tìm hiểu 3D/AR với Unity.
<a href = "pulls">
  <img alt="GitHub pull requests" src=https://img.shields.io/github/issues-pr/Luo1604/se2022-3.1>
</a>
<a href= "issues">
  <img alt="GitHub issues" src="https://img.shields.io/github/issues/Luo1604/se2022-3.1?style=plastic">
</a>
<a href= "closed">
  <img alt="GitHub closed issues" src="https://img.shields.io/github/issues-closed-raw/Luo1604/se2022-3.1">
</a>
<a href = "repo">
  <img alt="Repo size" src=https://img.shields.io/github/repo-size/Luo1604/se2022-3.1>
</a>  

Đề tài: Xây dựng app cho phép xem model ở 3D và AR với Unity.

## Description:
Ứng dụng Augmented Reality trên hệ điều hành Android sử dụng Google ARCore và Unity. Dựa trên model-viewer.  
Ứng dụng được test trên Redmi Note 11.   

https://github.com/Unity-Technologies/arfoundation-samples  
https://github.com/topics/model-viewer  

## Requirements:
Các thiết bị hỗ trợ Google Play Services for AR.
https://developers.google.com/ar/devices

Phiên bản Unity phù hợp 2021.2+

## Goals:
Load được file .glb và .gltf và hiển thị được nó dang 3D.

Hiển thị các model 3D đã nêu trên bằng AR(Augmented Reality).

## Result:
Load được các file .glb và .gltf lưu trữ trên các thiết bị Android phù hợp.

Hiển thị dạng 3D với các thao tác đơn giản trên model như xoay, phóng to.

Quét mập phẳng không gian thực và đặt được model trên mặt phẳng đó.

## Reference:
Unity Package đã sử dụng (ngoài AR Foundation và các gói AR tích hợp trên Unity):

GLTFUtility: Cho phép bạn import và export các tệp glTF, glb trong thời gian chạy và trong trình chỉnh sửa.

https://github.com/Siccity/GLTFUtility

UnitySimpleFileBrowser: Cho phép chọn tệp và lấy đường dẫn của tệp đó trên thiết bị của bạn

https://github.com/yasirkula/UnitySimpleFileBrowser

## Screenshots:
3D viewing mode:  
![image](https://user-images.githubusercontent.com/92431917/216575542-fd05d350-dd19-4a4c-81fb-48c3603c161c.png)

AR viewing mode:  
![image](https://user-images.githubusercontent.com/92431917/216575757-b118e5c5-ce8a-4532-9750-d9879a9c073a.png)
