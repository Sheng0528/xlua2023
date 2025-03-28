--[[
-- added by author @ 2025/2/20 22:07:22
-- UISettingUIMain模型层
-- 注意：
-- 1、成员变量预先在OnCreate、OnEnable函数声明，提高代码可读性
-- 2、OnCreate内放窗口生命周期内保持的成员变量，窗口销毁时才会清理
-- 3、OnEnable内放窗口打开时才需要的成员变量，窗口关闭后及时清理
-- 4、OnEnable函数每次在窗口打开时调用，可传递参数用来初始化Model
--]]
local UISettingModel = BaseClass("UISettingModel", UIBaseModel)


local base = UIBaseModel-- 创建
local function OnCreate(self)
	base.OnCreate(self)
	-- 窗口生命周期内保持的成员变量放这
end
-- 打开
local function OnEnable(self)
	base.OnEnable(self)
	-- 窗口关闭时可以清理的成员变量放这
end
-- 关闭
local function OnDestroy(self)
	base.OnDestroy(self)
	-- 清理成员变量
end


UISettingModel.OnCreate = OnCreate
UISettingModel.OnEnable = OnEnable
UISettingModel.OnDestroy = OnDestroy

return UISettingModel
