using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// Quản lí chức năng đăng nhập đăng kí 
/// </summary>
public static class Account_Management 
{


    private static FirebaseAuth _auth; // Lưu trữ instance của FirebaseAuth
    private static bool _isInitialized = false; // Đánh dấu xem đã khởi tạo chưa


    /// <summary>
    ///  Hàm khởi tạo và trả về FirebaseAuth
    /// </summary>
    /// <returns></returns>
    public static async Task<FirebaseAuth> FireBaseAuth_KDev()
{
// Nếu đã khởi tạo, trả về instance hiện tại
        if (_isInitialized && _auth != null)
        {
            return _auth;
        }

        // Kiểm tra và khởi tạo Firebase
        var dependencyStatus = await FirebaseApp.CheckAndFixDependenciesAsync();
        if (dependencyStatus != DependencyStatus.Available)
        {
            Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            return null;
        }

        // Lấy FirebaseAuth
        _auth = FirebaseAuth.DefaultInstance;
        if (_auth == null)
        {
            Debug.LogError("Failed to initialize FirebaseAuth.");
            return null;
        }

        _isInitialized = true;
        Debug.Log("FirebaseAuth initialized successfully.");
        return _auth;
        }




    /// <summary>
    /// CHỊU TRÁCH NHIỆM ĐĂNG KÍ TÀI KHOẢN NGƯỜI DÙNG
    /// </summary>
    /// <param name="register_Code"> đoạn code có các input đăng nhâp</param>
    /// <param name="firebaseAuth"></param>
    /// <returns></returns>
    public static async Task<bool> Regiser_FireBase_KDev( this Register_Code register_Code , FirebaseAuth  firebaseAuth ){

    try
    {
        var result = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(register_Code.email.text, register_Code.password.text);
        FirebaseUser firebaseUser = result.User;
        var profile_update = new  UserProfile{
            DisplayName = register_Code.user_name.text
        };
        await firebaseUser.UpdateUserProfileAsync(profile_update);
        
        Debug.Log($"Đăng ký thành công cho {result.User.Email}");
        await firebaseUser.SendEmailVerificationAsync();
        return true;
    }
    catch (System.Exception e)
    {
        Debug.LogError($"Đăng ký thất bại: {e.Message}");
        return false;
    }
    }


    /// <summary>
    ///  CHỊU TRÁCH NHIỆM ĐĂNG NHÂP TÀI KHOẢN NGƯỜI DÙNG
    /// </summary>
    /// <param name="login_Code"></param>
    /// <param name="firebaseAuth"></param>
    /// <returns></returns>
    public static async Task<bool> Login_FireBase_KDev( this Login_Code login_Code, FirebaseAuth firebaseAuth)
    {
        try
        {
            var result = await firebaseAuth.SignInWithEmailAndPasswordAsync(login_Code.email.text, login_Code.password.text);
            Debug.Log($"đăng nhập thành công: {result.User.Email}");

            FirebaseUser firebaseUser = result.User;

            if (firebaseUser.IsEmailVerified){
                Debug.Log("email đã xác minh");
                return true;
            }else{
                Debug.Log("email chưa xác minh");
                firebaseAuth.SignOut();
                return false;
            }
         
        }
        catch (FirebaseException exception)
        {
            Debug.LogError($"Sai gmail , hoặc mật khẩukhẩu: {exception.ErrorCode} - Message: {exception.Message} - Details: {exception.StackTrace}");
            return false;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Login failed: {e.Message}");
            return false;
        }
    }


   

    public static async Task<bool> Forgot_password_FireBase_KDev( this Forgot_password forgot_Password , FirebaseAuth firebaseAuth){
        try{
            await firebaseAuth.SendPasswordResetEmailAsync(forgot_Password.email.text);  // Await the Task here
            return true;
        }catch(System.Exception e){
            Debug.LogError($"Error: {e.Message}");
            return false;
        }
    }


}
