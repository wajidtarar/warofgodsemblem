/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package myExtPackage;

import com.smartfoxserver.v2.extensions.SFSExtension;

/**
 *
 * @author Hassan Ali Khan
 */
public class MainExtension extends SFSExtension{

    @Override
    public void init() {
        //throw new UnsupportedOperationException("Not supported yet.");
        addRequestHandler("SomeNumberHandle", SomeNumberHandle.class);
        addRequestHandler("updatexyz", Updatesxyz.class);
          addRequestHandler("UpdateLocations", UpdateLocations.class);
    }
    
}

