	--select * from share_img
	--select * from share
	
	declare @num int 
	declare @shareid int 
	declare @i int 
	set @num=24 
	set @shareid=12 
	set @i=1  
	insert into share (name,userid,isvalid,remark,collects,url,content)values ('简言碎语',0,0,
	'我们滚床单吗? 滚.',5,1,
	'我们滚床单吗? 滚.') 
	while (@i<@num+1)
	begin
	insert into share_img (sid,userid,isvalid,recorddate,shareid)values(@i,0,0,getdate(), @shareid)
	set @i=@i+1
	end
	
