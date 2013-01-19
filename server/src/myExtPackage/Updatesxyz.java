/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package myExtPackage;

import com.smartfoxserver.v2.entities.Room;
import com.smartfoxserver.v2.entities.User;
import com.smartfoxserver.v2.entities.Zone;
import com.smartfoxserver.v2.entities.data.ISFSObject;
import com.smartfoxserver.v2.extensions.BaseClientRequestHandler;
import java.util.List;
import java.util.Random;

/**
 *
 * @author Hassan Ali Khan
 */
public class Updatesxyz extends BaseClientRequestHandler{

    @Override
    public void handleClientRequest(User user, ISFSObject isfso) {
       // throw new UnsupportedOperationException("Not supported yet.");
        String name = isfso.getUtfString("name");
        Zone zone = user.getZone();
       
       Room room = zone.getRoomByName("The Game");
        String zonename = room.getName();
      // Room room= user.();
       List<User> usrList = room.getUserList();
     
    // 
        send("updatexyz", isfso, usrList);
    
    }
    
}

